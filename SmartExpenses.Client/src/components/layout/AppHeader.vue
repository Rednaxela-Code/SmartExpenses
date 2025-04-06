<script setup lang="ts"></script>
<template>
  <header>
    <div class="logo">
      <img src="@/assets/logo2.svg" alt="SmartExpenses" />
    </div>
    <h1>Smart Expenses App</h1>
    <nav class="nav">
      <ul>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/expense">Expenses</RouterLink>
        <RouterLink to="/user">Users</RouterLink>
        <RouterLink to="/">Settings</RouterLink>
      </ul>
    </nav>
  </header>
</template>
