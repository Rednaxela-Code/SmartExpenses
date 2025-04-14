<script setup lang="ts">
import { ref } from 'vue'
import { useAuth } from '@/utils/useAuth'

const email = ref('')
const password = ref('')
const { register } = useAuth()

const handleRegister = () => {
  register(email.value, password.value)
}
</script>

<template>
  <form @submit.prevent="handleRegister">
    <input v-model="email" type="email" placeholder="Email" required />
    <input v-model="password" type="password" placeholder="Password" required />
    <button type="submit">Register</button>
  </form>
</template>

