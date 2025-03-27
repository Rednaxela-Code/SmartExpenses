<template>
  <div class="container">
    <h1>Gebruikersbeheer</h1>
    <button @click="openDrawer" class="btn btn-primary">+ Gebruiker toevoegen</button>

    <UserFormDrawer :isOpen="isDrawerOpen" @close="closeDrawer" @save="addUser" />

    <ul class="user-list">
      <li v-for="user in users" :key="user.email">
        <strong>{{ user.name }}</strong> ({{ user.role }}) - {{ user.email }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import UserFormDrawer from '@/components/UserFormDrawer.vue'

const isDrawerOpen = ref(false)
const users = ref<{ name: string; email: string; role: string }[]>([])

function openDrawer() {
  isDrawerOpen.value = true
}

function closeDrawer() {
  isDrawerOpen.value = false
}

function addUser(newUser: { name: string; email: string; role: string }) {
  users.value.push(newUser)
}
</script>

<style>
.container {
  padding: 20px;
}

.user-list {
  margin-top: 20px;
  list-style: none;
  padding: 0;
}

.user-list li {
  padding: 10px;
  border-bottom: 1px solid #ddd;
}

.btn-primary {
  background-color: #007bff;
  color: white;
  padding: 8px 12px;
  border: none;
  cursor: pointer;
  border-radius: 4px;
}

.btn-primary:hover {
  background-color: #0056b3;
}
</style>
