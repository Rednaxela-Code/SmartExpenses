<template>
  <Teleport to="main">
    <Transition name="slide">
      <div v-if="isOpen" class="drawer-overlay" @click.self="close">
        <div class="drawer">
          <h2 class="drawer-header">Nieuwe gebruiker toevoegen</h2>

          <form @submit.prevent="submitForm">
            <div class="form-group">
              <label for="name">Naam</label>
              <input v-model="user.name" type="text" id="name" required />
            </div>

            <div class="form-group">
              <label for="email">E-mail</label>
              <input v-model="user.email" type="email" id="email" required />
            </div>

            <div class="form-group">
              <label for="role">Rol</label>
              <select v-model="user.role" id="role">
                <option value="admin">Admin</option>
                <option value="editor">Editor</option>
                <option value="viewer">Viewer</option>
              </select>
            </div>

            <div class="button-group">
              <button type="button" class="btn btn-secondary" @click="close">Annuleren</button>
              <button type="submit" class="btn btn-primary">Opslaan</button>
            </div>
          </form>
        </div>
      </div>
    </Transition>
  </Teleport>
</template>

<script setup lang="ts">
import { defineProps, defineEmits, ref } from 'vue'

defineProps<{ isOpen: boolean }>()
const emit = defineEmits(['close', 'save'])

const user = ref({
  name: '',
  email: '',
  role: 'viewer',
})

function close() {
  emit('close')
}

function submitForm() {
  emit('save', user.value)
  close()
}
</script>

<style>
/* Overlay achtergrond */
.drawer-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: flex-end;
  align-items: stretch;
  z-index: 1000;
}

/* Zijpaneel */
.drawer {
  width: 400px;
  background: white;
  height: 100%;
  padding: 20px;
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.2);
  overflow-y: auto;
  transition: transform 0.3s ease-in-out;
}

/* Slide-in animatie */
.slide-enter-active,
.slide-leave-active {
  transition: transform 0.3s ease-in-out;
}

.slide-enter-from,
.slide-leave-to {
  transform: translateX(100%);
}

/* Formulier stijlen */
.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

.form-group input,
.form-group select {
  width: 100%;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

/* Knoppen */
.button-group {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
}

.btn {
  padding: 8px 16px;
  border: none;
  cursor: pointer;
  font-size: 14px;
}

.btn-primary {
  background-color: #007bff;
  color: white;
  border-radius: 4px;
}

.btn-secondary {
  background-color: #ccc;
  color: black;
  border-radius: 4px;
}

.btn:hover {
  opacity: 0.8;
}
</style>
