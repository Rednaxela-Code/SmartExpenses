import axios from 'axios'

const httpClient = axios.create({
  baseURL: 'http://localhost:5232',
  timeout: 5000,
})

httpClient.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')
  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

export default httpClient
