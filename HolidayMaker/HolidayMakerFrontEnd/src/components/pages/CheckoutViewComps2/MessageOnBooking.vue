<template>
    <div>
        <h5>Basic</h5>
        <Textarea v-model="value1" rows="5" cols="30" />
    </div>
</template>

<script>
import Textarea from 'primevue/textarea';

export default {
    data() {
        return {
            value1: '',
            value2: '',
            value3: ''
        }
    },
    components:{
        Textarea,
    },
}
</script>

<style scoped>

</style>