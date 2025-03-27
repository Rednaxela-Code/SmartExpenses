import axios from 'axios'

export const httpClient = axios.create({
  baseURL: 'https://localhost:7195',
  timeout: 5000,
})

export default httpClient
