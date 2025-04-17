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
    <div class="content">
      <div v-if="currentTab === 0">
        <GeneralSettings />
      </div>
      <div v-else-if="currentTab === 1">
        <UserSettings />
      </div>
    </div>
  </main>
</template>

<style scoped>
header {
  justify-content: flex-start;
  background-color: transparent;
  border-bottom: 1px solid;
}

button {
  margin-left: 0.5rem
}

.content {
  margin: 0.5rem;
  margin-top: 1rem;

}
</style>
