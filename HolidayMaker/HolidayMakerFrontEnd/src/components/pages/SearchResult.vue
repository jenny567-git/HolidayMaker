<template>
        <Card id="test3">
      <template #content>
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
                        <li><a class="dropdown-item" v-on:click="sortListByPrice">Price: Lowest first</a></li>
                        <li><a class="dropdown-item" v-on:click="sortListByRating">Rating: Highest first</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <hr>
        <Filter @updateNrOfHotels="updateHotelsCount"/> 
            </template>     
        </Card>
    
</template>

<script>
import Filter from './SearchResultComponents/Filter.vue'
import Result from './SearchResultComponents/Result.vue'
import Card from 'primevue/card';
export default ({
    components:{
        Filter,
        Result,
        Card
    },
    data(){
        return{
            nrOfSearchResults: 0,
            searchResultList: []
        }
    },
    methods: {
        updateHotelsCount(count){
            this.nrOfSearchResults = count;
        },
        sortListByPrice(){
            this.searchResultList = this.$store.state.seachResults
            return this.searchResultList.sort((a, b) => 
                a.hotel.rooms[0].price - b.hotel.rooms[0].price 
                );
        },
        sortListByRating(){
            this.searchResultList = this.$store.state.seachResults
            return this.searchResultList.sort((a, b) => 
                b.hotel.averageRating - a.hotel.averageRating 
                );
        }
    },
})
</script>

<style scoped>
    
    #test3{
        border-radius:20px;
        margin-top:20px;
    }

    .dropdown{
        margin-top: 35px;
    }
    
    div.dropdown{
        margin-left:7cm;
    }

    a.dropdown-item{
        color:black !important;
    }
</style>