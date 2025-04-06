import httpClient from './httpClient'

export interface User {
  id: number
  name: string
  lastName: string
}

export const getAllUsers = async (): Promise<User[]> => {
  try {
    const response = await httpClient.get<User[]>('/user')
    return response.data // Always return an array
  } catch (error: unknown) {
    console.error('Error retrieving users:', error)
    return [] // Return an empty array instead of null
  }
}

export const createUser = async (user: User): Promise<User | null> => {
  try {
    const response = await httpClient.post('/user', user, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    console.log('User created successfully:', response.data)
    return response.data
  } catch (error) {
    console.error('Error creating user:', error)
    return null;
  }
}

export const updateUser = async (user: User): Promise<User | null> => {
  try {
    const response = await httpClient.put('/user', user, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    console.log('User updated successfully:', response.data)
    return response.data
  } catch (error) {
    console.error('Error updating user:', error)
    return null
  }
}

export const deleteUser = async (id: number): Promise<boolean> => {
  try {
    const response = await httpClient.delete(`/user?id=${id}`, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    if (response.status === 200) {
      console.log('Expense deleted successfully:', response.data)
      return true
    }
  } catch (error) {
    console.error('Error deleting user:', error)
  }
  return false
}
