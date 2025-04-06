<script setup lang="ts">
import { ref, watch, computed } from 'vue'
import { onClickOutside } from '@vueuse/core'

type Field = {
  key: string
  label: string
  type: 'text' | 'number' | 'textarea' // easy to extend
  required?: boolean
}

const props = defineProps<{
  isOpen: boolean
  title: string
  fields: Field[]
  modelValue: Record<string, any>
}>()

const emit = defineEmits(['update:modelValue', 'submit', 'modal-close'])

const localData = ref({ ...props.modelValue })
const target = ref(null)

onClickOutside(target, () => emit('modal-close'))

watch(() => props.modelValue, (val) => {
  localData.value = { ...val }
})

function handleSubmit() {
  emit('submit', { ...localData.value })
}
</script>

<template>
  <div v-if="isOpen" class="modal-mask">
    <div class="modal-wrapper">
      <div class="modal-container" ref="target">
        <div class="modal-header">
          <h2>{{ title }}</h2>
        </div>

        <div class="modal-body">
          <form class="modal-form" @submit.prevent="handleSubmit">
            <div v-for="field in fields" :key="field.key" class="form-field">
              <label :for="field.key">{{ field.label }}</label>
              <input
                v-if="field.type === 'text' || field.type === 'number'"
                :type="field.type"
                :id="field.key"
                v-model="localData[field.key]"
              />
              <textarea
                v-else-if="field.type === 'textarea'"
                :id="field.key"
                v-model="localData[field.key]"
              />
            </div>
          </form>
        </div>

        <div class="modal-footer">
          <slot name="footer">
            <button @click="handleSubmit" class="btn-p">Save</button>
            <button @click="$emit('modal-close')" class="btn-s">Cancel</button>
          </slot>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
}
.modal-container {
  width: 400px;
  margin: 150px auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
}
.form-field {
  margin-bottom: 1rem;
}
</style>
