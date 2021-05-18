<template>
  <div>
    <h1>{{ msg }}</h1>

    <p>
      <a href="https://vitejs.dev/guide/features.html" target="_blank">
        Vite Documentation
      </a>
      |
      <a href="https://v3.vuejs.org/" target="_blank">Vue 3 Documentation</a>
    </p>

    <button @click="state.count++">count is: {{ state.count }}</button>
    <p>
      Edit
      <code>components/HelloWorld.vue</code> to test hot module replacement.
    </p>
    <Button type="button" icon="pi pi-search" class="p-button-rounded p-button-success p-d-none p-d-md-inline-flex" Test/>
    <router-link to="/home">test | </router-link>
    <router-link to="/hotels/1">Hotel 1 | </router-link>
    <router-link to="/hotels/2">Hotel 2 | </router-link>
    <router-link to="/result">Search result view | </router-link>
    <router-link to="/addReview">Add review </router-link>
  </div>
</template>

<script setup>
import { defineProps, reactive } from 'vue'
import Button from 'primevue/Button';
defineProps({
  msg: String,
  component:{
    Button
  }
})

const state = reactive({ count: 0 })
</script>

<style scoped>
a {
  color: #42b983;
}
</style>
