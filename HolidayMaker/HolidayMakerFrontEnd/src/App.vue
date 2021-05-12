<template>
 <div class="input-group">
    <ConfirmDate />
    
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

.input-group{
    margin-left: auto;
    margin-right: auto;
    display: flex;
    width: fit-content;
    align-content: center;
}


</style>
