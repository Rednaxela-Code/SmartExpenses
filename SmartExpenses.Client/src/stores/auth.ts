import { defineStore } from 'pinia'
import { jwtDecode } from "jwt-decode";
import httpClient from "@/utils/httpClient.ts";

interface JwtPayload {
  sub: string
  email: string
  member_id: string
  account_id: string
  display_name: string
  role?: string | string[]
}

let refreshTimeout: ReturnType<typeof setTimeout> | null = null

export const useAuthStore = defineStore('auth', {
  state: () => ({
    token: localStorage.getItem('token') ?? '',
    user: null as JwtPayload | null,
  }),
  getters: {
    isAuthenticated: (state) => !!state.token,
    memberId: (state) => state.user?.member_id ?? '',
    accountId: (state) => state.user?.account_id ?? '',
    role: (state) => {
      const r = state.user?.role
      if (!r) return []
      return Array.isArray(r) ? r : [r]
    },
  },
  actions: {
    setToken(token: string) {
      this.token = token
      localStorage.setItem('token', token)
      this.user = jwtDecode<JwtPayload>(token)
      this.scheduleRefresh(token)
    },
    scheduleRefresh(token: string) {
      const payload = jwtDecode<{ exp: number }>(token)
      const expiresAt = payload.exp * 1000
      const now = Date.now()
      const refreshIn = expiresAt - now - 2 * 60 * 1000 // refresh 2 min before expiry

      if (refreshIn <= 0) return

      if (refreshTimeout) clearTimeout(refreshTimeout)
      refreshTimeout = setTimeout(this.refreshAccessToken, refreshIn)
    },
    async refreshAccessToken() {
      const refreshToken = localStorage.getItem('refreshToken')
      if (!refreshToken) return this.logout()

      try {
        const res = await httpClient.post('/auth/refresh', { refreshToken })
        this.setToken(res.data.accessToken)
        localStorage.setItem('refreshToken', res.data.refreshToken)
      } catch (err) {
        console.error('Auto refresh failed:', err)
        this.logout()
      }
    },
    logout() {
      this.token = ''
      this.user = null
      localStorage.removeItem('token')
      localStorage.removeItem('refreshToken')
      if (refreshTimeout) clearTimeout(refreshTimeout)
    },
    fetchUser() {
      if (this.token) {
        this.user = jwtDecode<JwtPayload>(this.token)
      }
    },
  },
})
