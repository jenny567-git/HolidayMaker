<template>
<b-container>
   <datepicker v-model="datepicker_1"></datepicker>
   <datepicker v-model="datepicker_2"></datepicker>
   
</b-container>

</template>

<script>
import Datepicker from 'vue3-datepicker'


export default {
    name: 'ConfirmDate',
    components: {
        Datepicker
    },
    data() {
        return {
          datepicker_1: '',
          datepicker_2: '',
          
        }
    },

   
}
</script>

<style>
.b-container{
    margin-left: auto;
    margin-right: auto;
    display: flex;
    width: fit-content;
    align-content: center;
}

</style>