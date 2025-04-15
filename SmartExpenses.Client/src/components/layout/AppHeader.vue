<script setup lang="ts">
import {useAuth} from "@/utils/useAuth.ts";

const {logout} = useAuth()

</script>

<template>
  <header>
    <div class="logo">
      <img src="@/assets/logo2.svg" alt="SmartExpenses"/>
    </div>
    <h1>Smart Expenses App</h1>
    <nav class="nav">
      <ul>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/expense">Expenses</RouterLink>
        <RouterLink to="/user">Users</RouterLink>
        <RouterLink to="/">Settings</RouterLink>
        <button class="btn-p" @click="logout">Logout</button>
      </ul>
    </nav>
  </header>
</template>
