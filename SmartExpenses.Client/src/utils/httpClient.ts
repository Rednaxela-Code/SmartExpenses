import axios from 'axios'

export const httpClient = axios.create({
  baseURL: 'http://localhost:5232',
  timeout: 5000,
})

export default httpClient
