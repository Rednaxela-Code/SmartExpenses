<script setup lang="ts">
import {ref} from 'vue'
import {useAuth} from '@/utils/useAuth'

const email = ref('')
const password = ref('')
const {register} = useAuth()

const handleRegister = () => {
  register(email.value, password.value)
}
</script>

<template>
  <div class="auth-container">
    <form @submit.prevent="handleRegister" class="auth-form">
      <label for="email">Email</label>
      <input v-model="email" type="email" placeholder="Email" required/>
      <label for="password" class="auth-pwd">Password</label>
      <input v-model="password" type="password" placeholder="Password" required/>
      <button class="btn-p auth-btn" type="submit">
        Register
      </button>
    </form>
  </div>
</template>
