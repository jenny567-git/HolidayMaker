<template>
    <div>
        <h5>Personal Detail</h5>
        <span class="p-float-label">
            <InputText id="username" type="text" v-model="value" />
            <label for="username">Name</label>
        </span>
        <div>
            <Button label="Primary" />
            <Button label="Primary" />
        </div>
    </div>
</template>

<script>
import { defineComponent } from '@vue/composition-api'
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';

export default {
    components:{
        InputText,
        Button
    },
}
</script>

<style scoped>

</style>
