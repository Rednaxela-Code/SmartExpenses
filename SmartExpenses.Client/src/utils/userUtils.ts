import httpClient from './httpClient'

export interface User {
  id: number
  name: string
  lastName: string
}

export const getAllUsers = async (): Promise<User[]> => {
  try {
    const response = await httpClient.get('/user')
    console.log('Users retrieved successfull:', response.data)
    return response.data
  } catch (error) {
    console.log('Error retrieving users:', error)
    throw error
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
