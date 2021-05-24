
<template>
    <div>
        <PersonalDetail />
        
        <div class="card">
            <Steps :model="items" :readonly="true" />
        </div>

        <router-view v-slot="{Component}" :formData="formObject" @prevPage="prevPage($event)" @nextPage="nextPage($event)" @complete="complete">
            <keep-alive>
                <component :is="Component" />
            </keep-alive>
        </router-view>
    </div>
</template>

<script>
import PersonalDetail from './CheckoutViewComps2/PersonalDetail.vue'

export default {
    data() {
        return {
            items: [{
                label: 'Personal',
                to: '/steps'
            },
            {
                label: 'Message',
                to: '/steps/message'
            },
            {
                label: 'Payment',
                to: '/steps/payment'
            },
            {
                label: 'Confirmation',
                to: '/confirmation'
            }],
            formObject: {}
        }
    },
    methods: {
        nextPage(event) {
            for (let field in event.formData) {
                this.formObject[field] = event.formData[field];
            }

            this.$router.push(this.items[event.pageIndex + 1].to);
        },
        prevPage(event) {
            this.$router.push(this.items[event.pageIndex - 1].to);
        },
        complete() {
            this.$toast.add({severity:'success', summary:'Order submitted', detail: 'Dear, ' + this.formObject.firstname + ' ' + this.formObject.lastname + ' your order completed.'});
        }
    },
    components: {
        PersonalDetail
    }
}
</script>

<style scoped lang="scss">
::v-deep(b) {
    display: block;
}

::v-deep(.p-card-body) {
    padding: 2rem;
}
</style>