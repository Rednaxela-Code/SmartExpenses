<script setup lang="ts">
defineProps<{
    columns: { key: string; label: string }[]
    rows: any[]
    selectedRow?: any
    onRowClick?: (row: any) => void
}>()
</script>

<template>
    <table class="content-table">
        <caption></caption>
        <thead>
            <tr>
                <th v-for="col in columns" :key="col.key">{{ col.label }}</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="row in rows" :key="row.id" @click="onRowClick?.(row)"
                :class="{ selectedRowStyling: selectedRow?.id === row.id }">
                <td v-for="col in columns" :key="col.key">
                    <span v-if="col.key === 'amount'">&euro;</span>
                    {{ row[col.key] }}
                </td>
            </tr>
        </tbody>
    </table>
</template>