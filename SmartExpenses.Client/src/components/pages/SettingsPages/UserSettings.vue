<script setup lang="ts">

import AppTable from "@/components/layout/AppTable.vue";
import type {Column} from "@/types/Column.ts";

const columns: Column[] = [
  { key: 'name', label: 'Name' },
  { key: 'email', label: 'Email' },
]
</script>

<template>
  <AppTable
    :columns="columns"
    :rows="users" />
</template>

<style scoped>

</style>
