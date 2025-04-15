<script setup lang="ts">
import GeneralSettings from "@/components/pages/SettingsPages/GeneralSettings.vue";
import UserSettings from "@/components/pages/SettingsPages/UserSettings.vue";
import {ref} from "vue";

const currentTab = ref(0)
</script>

<template>
  <main>
  <header>
    <button @click="currentTab = 0">
      General
    </button>
    <button @click="currentTab = 1">
      Users
    </button>
  </header>
    <div v-if="currentTab === 0">
      <GeneralSettings />
    </div>
    <div v-else-if="currentTab === 1">
      <UserSettings />
    </div>
  </main>
</template>

<style scoped>
header {
  justify-content: flex-start;
}

button {
  margin-left: 0.5rem
}
</style>
