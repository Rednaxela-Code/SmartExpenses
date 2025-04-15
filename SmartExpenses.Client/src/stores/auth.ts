import { defineStore } from 'pinia'
import {jwtDecode} from "jwt-decode";

interface JwtPayload {
  sub: string
  email: string
  member_id: string
  account_id: string
  display_name: string
  role?: string | string[]
}

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
    },
    logout() {
      this.token = ''
      this.user = null
      localStorage.removeItem('token')
    },
    fetchUser() {
      if (this.token) {
        this.user = jwtDecode<JwtPayload>(this.token)
      }
    },
  },
})
