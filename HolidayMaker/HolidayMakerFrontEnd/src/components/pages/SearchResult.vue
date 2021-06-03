<template>
    <div id="test2">
        <div class="row pt-5">
            <div class="col-md-6">
                
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

            <!-- <div class="col"> -->

                <!-- OPTION 1: CHECKBOX -->
                <!-- <div class="btn-group" role="group" aria-label="Basic radio toggle button group">
                    <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked>
                    <label class="btn btn-outline-primary" for="btnradio1">Price: Lowest first</label>
                    <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off">
                    <label class="btn btn-outline-primary" for="btnradio2">Rating: Highest first</label>
                </div> -->


                <!-- OPTION 2 : DROPDOWN -->
                <!-- <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        Sort by
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><a class="dropdown-item" href="#">Price: Lowest first</a></li>
                        <li><a class="dropdown-item" href="#">Rating: Highest first</a></li>
                        <li><a class="dropdown-item" href="#">Distance to centrum: Nearest first</a></li>
                    </ul>
                </div> -->
                
            <!-- </div> -->
                <Filter /> 

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
</style>