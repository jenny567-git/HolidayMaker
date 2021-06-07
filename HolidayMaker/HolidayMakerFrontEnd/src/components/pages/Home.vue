<template>
    <div>
        <h1 id="welcome">Welcome to Africa Motherfucker!</h1>
        
    </div>
</template>
<script>
import Body from "./MainPage/Body.vue";
export default {
    components:{
        Body
    }
}
</script>
<style scoped>
    /* #homeDiv{
        margin-top: 500px;
    } */
    figure {
    margin: 0;
}


    #welcome{
        font-size: 3em;
        color: rgb(189 158 101) !important;
        padding-top: 20px;
        text-shadow: 2px 2px black;
    }

    a{
        color: rgb(189 158 101);
    }

    a :hover{
        list-style: none;
    }
</style>