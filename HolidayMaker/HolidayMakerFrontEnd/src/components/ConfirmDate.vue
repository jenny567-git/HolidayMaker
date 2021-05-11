<template>
   
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
            date: '',
            time: '',
            timePickerOption: {
                start: '00:00',
                step: '00:30',
                end: '23:30'
            },
            datetime: '',
            range: '',
            shortcuts: [
                {
                    text: 'Today',
                    onClick: () => {
                        this.range = [ new Date(), new Date() ]
                    }
                }
            ]
        }
    }
}
</script>

<style>

</style>