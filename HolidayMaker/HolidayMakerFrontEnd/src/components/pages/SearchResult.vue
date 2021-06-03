<template>
    <div id="test2">
        <div class="row">
            <div class="col-md-6">
                <h1>Search results: {{nrOfSearchResults}} found</h1>
            </div>
            <div class="col-md-6">
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        Sort by
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><a class="dropdown-item" href="#">Price: Lowest first</a></li>
                        <li><a class="dropdown-item" href="#">Rating: Highest first</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <hr>
        <Filter @updateNrOfHotels="updateHotelsCount" /> 
    </div>
</template>

<script>
import Filter from './SearchResultComponents/Filter.vue'
import Result from './SearchResultComponents/Result.vue'
export default ({
    components:{
        Filter,
        Result
    },
    data(){
        return{
            nrOfSearchResults: 0,
        }
    },
    methods: {
        updateHotelsCount(count){
            this.nrOfSearchResults = count;
        }
    },
})
</script>

<style scoped>
    #test2{
        border-radius: 30px;
        background-color: rgba(107, 146, 83, 0.5);
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 40px;
        margin-top: 20px;
    }
    .dropdown{
        margin-top: 35px;
    }
</style>