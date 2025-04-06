<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { createUser, deleteUser, getAllUsers, updateUser, type User } from '@/utils/userUtils'
import AppModal from '@/components/layout/AppModal.vue'
import AppTable from '@/components/layout/AppTable.vue'
import type { Field } from '@/types/Field'

const showModal = ref(false)
const modalMode = ref<'add' | 'edit'>('add')

const user = ref<User>({
  id: 0,
  name: '',
  lastName: '',
})

const columns = [
  { key: 'id', label: '#' },
  { key: 'name', label: 'Name' },
  { key: 'lastName', label: 'Last Name' },
]

const formData = ref<User>({
  id: 0,
  name: '',
  lastName: ''
})

const fields: Field[] = [
  { key: 'id', label: 'Id', type: 'number' },
  { key: 'name', label: 'Name', type: 'text' },
  { key: 'lastName', label: 'Last Name', type: 'text' },
]

const users = ref<User[]>([])
const selectedRow = ref<User | null>(null)
const isAddModalOpened = ref(false)
const isEditModalOpened = ref(false)

const openAddModal = () => {
  modalMode.value = 'add'
  formData.value = {
    id: 0,
    name: '',
    lastName: ''
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

const handleSubmit = async (data: User) => {
  if (modalMode.value === 'add') {
    await createUser(data)
  } else {
    await updateUser(data)
  }
  showModal.value = false
  await fetchUsers()
}

const deleteHandler = async () => {
  if (selectedRow.value) {
    await deleteUser(selectedRow.value.id)
    users.value = users.value.filter(e => e.id !== selectedRow.value?.id)
    selectedRow.value = null
  }
}

function selectRow(row: User) {
  selectedRow.value = row
  // console.log('Geselecteerde rij:', row)
}

const fetchUsers = async () => {
  try {
    const userData = await getAllUsers()
    users.value = userData ?? [] // Fallback to empty array if null
  } catch (error) {
    console.error('Unexpected error:', error)
  }
}

onMounted(() => {
  fetchUsers()
})
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

  <main class="inner-page">
    <AppTable :columns="columns" :rows="users" :selected-row="selectedRow" :onRowClick="selectRow" />
    <div class="btn-row">
      <button v-if="users.length !== 0" @click="openEditModal" class="btn-p">Edit</button>
      <button v-if="users.length !== 0" @click="deleteHandler" class="btn-p">Delete</button>
      <button @click="openAddModal" class="btn-p">Add</button>
    </div>
  </main>
</template>
