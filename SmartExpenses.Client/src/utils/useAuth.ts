import { ref } from 'vue'
import router from '../router'
import httpClient from "@/utils/httpClient.ts";
import {useAuthStore} from "@/stores/auth.ts";

const token = ref<string | null>(localStorage.getItem('token'))
const user = ref<any>(null)

function getStore() {
  return useAuthStore()
}

export function useAuth() {
  async function login(email: string, password: string) {
    const response = await httpClient.post('/auth/login', { email, password })

    const accessToken = response.data.accessToken
    const refreshToken = response.data.refreshToken

    token.value = accessToken
    localStorage.setItem('token', accessToken)
    localStorage.setItem('refreshToken', refreshToken)

    getStore().setToken(accessToken)
    await fetchUser()

    router.push('/')
  }

  async function register(email: string, password: string) {
    await httpClient.post('/auth/register', { email, password })
    await login(email, password)
  }

  async function fetchUser() {
    try {
      const response = await httpClient.get('/auth/me')
      user.value = response.data
    } catch (err) {
      console.error('fetchUser failed:', err)
      logout()
    }
  }

  async function logout() {
    try {
      await httpClient.post('/auth/logout')
    } catch (err) {
      console.warn('Logout request failed:', err)
    }

    getStore().logout()
    token.value = null
    user.value = null
    localStorage.removeItem('token')
    localStorage.removeItem('refreshToken')
    router.replace('/login')
  }


  return {
    token,
    user,
    login,
    register,
    logout,
    fetchUser,
  }
}
