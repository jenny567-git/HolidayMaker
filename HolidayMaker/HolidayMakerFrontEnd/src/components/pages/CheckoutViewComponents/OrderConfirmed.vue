<template >
    <div>
        
        <Card class="cardStyle">
            <template #title>
                Order successful!
            </template>
            <template #content>
                <img alt="Confirmed" src="https://raw.githubusercontent.com/PKief/vscode-markdown-checkbox/master/logo.png" class="rounded-circle" id="orderPic"/>
                
            </template>
        </Card>
    </div>
</template>
<script>
import Card from 'primevue/card';
export default {
    components:{
        Card,
    }
}
</script>
<style scoped>
    #orderPic {
        width: 100px;
        height: 100px;
    }
    .cardStyle{
        margin-top: 30px;
    }
</style>