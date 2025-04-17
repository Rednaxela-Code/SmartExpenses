<script setup lang="ts">
import AppArticle from '@/components/layout/AppArticle.vue'
import AppHero from '@/components/layout/AppHero.vue'
import {useAuthStore} from "@/stores/auth.ts";

const auth = useAuthStore();
</script>

<template>
  <main class="landing-page">
    <AppHero />

    <section class="articles">
      <!-- Maak apparticles templates voor multifunctioneel gebruik -->
      <div>
        <p>Welcome, {{ auth.user?.display_name }}</p>
        <p>Your account ID is: {{ auth.accountId }}</p>
      </div>
      <AppArticle />
      <AppArticle />
      <AppArticle />
    </section>
  </main>
</template>
