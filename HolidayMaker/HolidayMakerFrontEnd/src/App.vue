<template>
  <div>
    <div class="datepicker">
    <confirmdate v-model="value" selectionMode="range" />
  </div>
  </div>
</template>

<script>
import ConfirmDate from './components/ConfirmDate.vue'

export default {
  name: 'App',
  components: {
    ConfirmDate
  }
}

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}


</style>
