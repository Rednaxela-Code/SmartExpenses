import httpClient from "./httpClient";

export interface Expense {
    id: number;
    name: string;
    description: string;
    amount: number;
    userId: number;
  }

  export const getAllExpenses = async (): Promise<Expense[]> => {
    try {
      const response = await httpClient.get<Expense[]>('/Expense')
      return response.data // Always return an array
    } catch (error: unknown) {
      console.error('Error retrieving Expenses:', error)
      return [] // Return an empty array instead of null
    }
  }
  
  export const createExpense = async (expense: Expense): Promise<Expense | null> => {
    try {
      const response = await httpClient.post('/Expense', expense, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      console.log('Expense created successfully:', response.data)
      return response.data
    } catch (error) {
      console.error('Error creating Expense:', error)
      return null
    }
  }
  
  
  export const updateExpense = async (expense: Expense): Promise<Expense | null> => {
    try {
      const response = await httpClient.put('/Expense', expense, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      console.log('Expense updated successfully:', response.data)
      return response.data
    } catch (error) {
      console.error('Error updating Expense:', error)
      return null
    }
  }
  
  export const deleteExpense = async (id: number): Promise<boolean> => {
    try {
      const response = await httpClient.delete(`/Expense?id=${id}`, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
  
      if (response.status === 200) {
        console.log('Expense deleted successfully:', response.data)
        return true
      }
    } catch (error) {
      console.error('Error deleting Expense:', error)
    }
  
    return false
  }