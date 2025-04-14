import { ref } from 'vue'
import router from '../router'
import httpClient from "@/utils/httpClient.ts";

const token = ref<string | null>(localStorage.getItem('token'))
const user = ref<any>(null)

export function useAuth() {
  async function login(email: string, password: string) {
    const response = await httpClient.post('/auth/login', { email, password })
    token.value = response.data.token
    localStorage.setItem('token', token.value!)
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
      logout()
    }
  }

  function logout() {
    token.value = null
    user.value = null
    localStorage.removeItem('token')
    router.push('/login')
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
