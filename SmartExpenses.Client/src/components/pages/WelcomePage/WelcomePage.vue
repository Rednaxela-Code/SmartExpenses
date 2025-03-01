<script setup lang="ts">
import AppArticle from '@/components/layout/AppArticle.vue'
import AppHero from '@/components/layout/AppHero.vue'
</script>

<template>
  <main class="landing-page">
    <AppHero />

    <section class="articles">
      <!-- Maak apparticles templates voor multifunctioneel gebruik -->
      <AppArticle />
      <AppArticle />
      <AppArticle />
    </section>
  </main>
</template>
