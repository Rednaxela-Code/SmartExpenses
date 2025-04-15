import httpClient from './httpClient'
import type { User } from '@/types/User.ts'


export const getAllUsers = async (): Promise<User[]> => {
  try {
    const response = await httpClient.get<User[]>('/user')
    return response.data // Always return an array
  } catch (error: unknown) {
    console.error('Error retrieving users:', error)
    return [] // Return an empty array instead of null
  }
}

export const createUser = async (user: User) => {
  try {
    const response = await httpClient.post('/user', user, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    console.log('User created successfully:', response.data)
  } catch (error) {
    console.error('Error creating user:', error)
  }
}

export const updateUser = async (user: User) => {
  try {
    const response = await httpClient.put('/user', user, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    console.log('User updated successfully:', response.data)
  } catch (error) {
    console.error('Error updating user:', error)
  }
}

export const deleteUser = async (id: number) => {
  try {
    const response = await httpClient.delete(`/user?id=${id}`, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    console.log('User deleted successfully:', response.data)
  } catch (error) {
    console.error('Error deleting user:', error)
  }
}
