<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { createUser, deleteUser, getAllUsers, updateUser, type User } from '@/utils/userUtils'
import AppModal from '@/components/layout/AppModal.vue'
import AppTable from '@/components/layout/AppTable.vue'

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
const users = ref<User[]>([])
const selectedRow = ref<User | null>(null)
const isAddModalOpened = ref(false)
const isEditModalOpened = ref(false)

const openAddModal = () => {
  isAddModalOpened.value = true
}

const closeAddModal = () => {
  isAddModalOpened.value = false
}

const openEditModal = () => {
  isEditModalOpened.value = true
}

const closeEditModal = () => {
  isEditModalOpened.value = false
}

const submitHandler = () => {
  if (user.value.name != '') {
    // Send to api
    console.log(user)
    const result = createUser(user.value)
    console.log(result)
  }
}

const editHandler = () => {
  if (selectedRow.value) {
    console.log(selectedRow.value)
    // Send to api
    const result = updateUser(selectedRow.value)
    console.log(result)
  }
}

const deleteHandler = () => {
  if (selectedRow.value) {
    const id = selectedRow.value.id
    console.log(selectedRow.value)
    const result = deleteUser(id)
    console.log(result)
    users.value = users.value.filter((u) => u.id !== id)
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
  <AppModal :isOpen="isAddModalOpened" @modal-close="closeAddModal" name="add-modal">
    <template #header
      ><h2>Add User</h2>
      <hr />
    </template>

    <template #content>
      <form class="modal-form">
        <label for="fname">Name</label><br />
        <input type="text" v-model="user.name" />
        <br />
        <label for="fname">Last Name</label><br />
        <input type="text" v-model="user.lastName" />
      </form>
    </template>
    <template #footer>
      <div class="btn-row-modal">
        <button @click="submitHandler" class="btn-p">Save</button>
        <button @click="closeAddModal" class="btn-s">Cancel</button>
      </div>
    </template>
  </AppModal>

  <AppModal :isOpen="isEditModalOpened" @modal-close="closeEditModal" name="edit-modal">
    <template #header
      ><h2 style="color: var(--accent-color)">Edit User</h2>
      <hr />
    </template>

    <template #content>
      <form v-if="selectedRow" class="modal-form">
        <label for="fname">Name</label><br />
        <input type="text" v-model="selectedRow.name" :disabled="!selectedRow" />

        <br />
        <label for="fname">Last Name</label><br />
        <input type="text" v-model="selectedRow.lastName" :disabled="!selectedRow" />
      </form>
    </template>
    <template #footer>
      <div class="btn-row-modal">
        <button @click="editHandler" class="btn-p">Save</button>
        <button @click="closeEditModal" class="btn-s">Cancel</button>
      </div>
    </template>
  </AppModal>

  <main class="inner-page">
    <AppTable
        :columns="columns"
        :rows="users"
        :selected-row="selectedRow"
        :onRowClick="selectRow" />
    <div class="btn-row">
      <button v-if="users.length !== 0" @click="openEditModal" class="btn-p">Edit</button>
      <button v-if="users.length !== 0" @click="deleteHandler" class="btn-p">Delete</button>
      <button @click="openAddModal" class="btn-p">Add</button>
    </div>
  </main>
</template>
