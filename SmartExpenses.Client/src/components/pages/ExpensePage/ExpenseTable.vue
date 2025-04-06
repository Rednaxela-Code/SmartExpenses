<script setup lang="ts">
import { createExpense, deleteExpense, getAllExpenses, updateExpense, type Expense } from '@/utils/expenseUtils';
import { onMounted, ref } from 'vue';
import AppModal from '@/components/layout/AppModal.vue'
import AppTable from '@/components/layout/AppTable.vue';


const expense = ref<Expense>({
    id: 0,
    name: '',
    description: '',
    amount: 0,
    userId: 0
});

const columns = [
  { key: 'id', label: '#' },
  { key: 'name', label: 'Name' },
  { key: 'amount', label: 'Amount' },
  { key: 'userId', label: 'User' },
  { key: 'description', label: 'Description' }
]

const expenses = ref<Expense[]>([])
const selectedRow = ref<Expense | null>(null)
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
    if (expense.value.name != '') {
        // Send to api
        console.log(expense)
        const result = createExpense(expense.value)
        console.log(result)
    }
}

const editHandler = () => {
    if (selectedRow.value) {
        console.log(selectedRow.value)
        // Send to api
        const result = updateExpense(selectedRow.value)
        console.log(result)
    }
}

const deleteHandler = () => {
    if (selectedRow.value) {
        const id = selectedRow.value.id
        console.log(selectedRow.value)
        const result = deleteExpense(id)
        console.log(result)
        expenses.value = expenses.value.filter((u) => u.id !== id)
    }
}

function selectRow(row: Expense) {
    selectedRow.value = row
    // console.log('Geselecteerde rij:', row)
}

const fetchExpenses = async () => {
    try {
        const userData = await getAllExpenses()
        expenses.value = userData ?? [] // Fallback to empty array if null
    } catch (error) {
        console.error('Unexpected error:', error)
    }
}

onMounted(() => {
    fetchExpenses()
})
</script>

<template>
    <AppModal :isOpen="isAddModalOpened" @modal-close="closeAddModal" name="add-modal">
        <template #header>
            <h2>Add Expense</h2>
            <hr />
        </template>

        <template #content>
            <form class="modal-form">
                <label for="fname">Name</label><br />
                <input type="text" v-model="expense.name" />
                <br />
                <label for="fname">Amount</label><br />
                <input type="text" v-model="expense.amount" />
                <br />
                <label for="fname">User</label><br />
                <input type="text" v-model="expense.userId" />
                <br />
                <label for="fname">Description</label><br />
                <input type="text" v-model="expense.description" />
                <br />
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
        <template #header>
            <h2 style="color: var(--accent-color)">Edit Expense</h2>
            <hr />
        </template>

        <template #content>
            <form v-if="selectedRow" class="modal-form">
                <label for="fname">Name</label><br />
                <input type="text" v-model="expense.name" />
                <br />
                <label for="fname">Amount</label><br />
                <input type="text" v-model="expense.amount" />
                <br />
                <label for="fname">User</label><br />
                <input type="text" v-model="expense.userId" />
                <br />
                <label for="fname">Description</label><br />
                <input type="text" v-model="expense.description" />
                <br />
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
        :rows="expenses"
        :selected-row="selectedRow"
        :onRowClick="selectRow" />

        <div class="btn-row">
            <button v-if="expenses.length !== 0" @click="openEditModal" class="btn-p">Edit</button>
            <button v-if="expenses.length !== 0" @click="deleteHandler" class="btn-p">Delete</button>
            <button @click="openAddModal" class="btn-p">Add</button>
        </div>
    </main>
</template>