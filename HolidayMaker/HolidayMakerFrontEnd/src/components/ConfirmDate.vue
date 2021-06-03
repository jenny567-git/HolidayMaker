<template>
<b-container>
   <datepicker v-model="datepicker_1" ></datepicker>
   <datepicker v-model="datepicker_2"></datepicker>
    
</b-container>

</template>

<script>
import Datepicker from 'vue3-datepicker'
import { ref } from 'vue'
const example2 = ref(new Date())
const example1 = ref(new Date())
const example2_from = ref(new Date())
const example2_to = ref(new Date())


export default {
    name: 'ConfirmDate',
    components: {
        Datepicker,
       
    },
   
    data() {
        const now = new Date()
        const today = new Date(now.getFullYear, now.getMonth, now.getDay)
        

        const datepicker_1_min_date = new Date()
       
        return {
          example2: '',
          datepicker_2: '',
          datepicker_1:'',
          min: datepicker_1_min_date
        }
    },

    methods: {
        dateDisabled(ymd, date){
            const weekday = date.getDay()
            const day = date.getDate()

            return weekday === new Date()
        }
    }
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
