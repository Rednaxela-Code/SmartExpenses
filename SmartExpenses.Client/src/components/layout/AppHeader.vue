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
        <RouterLink to="/">Budget</RouterLink>
        <RouterLink to="/user">Gebruikers</RouterLink>
        <RouterLink to="/">Instellingen</RouterLink>
      </ul>
    </nav>
  </header>
</template>
