<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { getAllExpenses, createExpense, updateExpense, deleteExpense, type Expense } from '@/utils/expenseUtils'
import AppModal from '@/components/layout/AppModal.vue'
import AppTable from '@/components/layout/AppTable.vue'
import type { Field } from '@/types/Field'

const expenses = ref<Expense[]>([])
const selectedRow = ref<Expense | null>(null)
const showModal = ref(false)
const modalMode = ref<'add' | 'edit'>('add')

const formData = ref<Expense>({
  id: 0,
  name: '',
  description: '',
  amount: 0,
  userId: 0
})

const fields: Field[] = [
  { key: 'name', label: 'Name', type: 'text' },
  { key: 'amount', label: 'Amount', type: 'number' },
  { key: 'userId', label: 'User ID', type: 'number' },
  { key: 'description', label: 'Description', type: 'textarea' }
]

const fetchExpenses = async () => {
  const data = await getAllExpenses()
  expenses.value = data ?? []
}

const openAddModal = () => {
  modalMode.value = 'add'
  formData.value = {
    id: 0,
    name: '',
    description: '',
    amount: 0,
    userId: 0
  }
  showModal.value = true
}

const openEditModal = () => {
  if (selectedRow.value) {
    modalMode.value = 'edit'
    formData.value = { ...selectedRow.value }
    showModal.value = true
  }
}

const handleSubmit = async (data: Expense) => {
  if (modalMode.value === 'add') {
    const newExpense = await createExpense(data)
    if (newExpense) {
      expenses.value.push(newExpense)
    }
  } else {
    const updatedExpense = await updateExpense(data)
    if (updatedExpense) {
      expenses.value.push(updatedExpense)
    }
  }
  showModal.value = false
}

const deleteHandler = async () => {
  if (selectedRow.value) {
    const success = await deleteExpense(selectedRow.value.id)

    if (success) {
      expenses.value = expenses.value.filter(e => e.id !== selectedRow.value?.id)
      selectedRow.value = null
    } else {
      console.warn('Delete failed – keeping expense in list')
    }
  }
}

function selectRow(row: Expense) {
  selectedRow.value = row
}

onMounted(fetchExpenses)
</script>

<template>
  <AppModal
    v-model:modelValue="formData"
    :isOpen="showModal"
    :title="modalMode === 'add' ? 'Add Expense' : 'Edit Expense'"
    :fields="fields"
    @submit="handleSubmit"
    @modal-close="showModal = false"
  />

  <AppTable
    :columns="[
      { key: 'id', label: '#' },
      { key: 'name', label: 'Name' },
      { key: 'amount', label: 'Amount' },
      { key: 'userId', label: 'User' },
      { key: 'description', label: 'Description' }
    ]"
    :rows="expenses"
    :selected-row="selectedRow"
    :onRowClick="selectRow"
  />

  <div class="btn-row">
    <button @click="openEditModal" :disabled="!selectedRow" class="btn-p">Edit</button>
    <button @click="deleteHandler" :disabled="!selectedRow" class="btn-p">Delete</button>
    <button @click="openAddModal" class="btn-p">Add</button>
  </div>
</template>
