<script setup lang="ts"></script>
<template>
  <header>
    <div class="logo">
      <img src="@/assets/logo2.svg" alt="SmartExpenses" />
    </div>
    <h4>SmartExpenses</h4>
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
