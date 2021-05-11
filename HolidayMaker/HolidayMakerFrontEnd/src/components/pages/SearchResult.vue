<template>
    <div>
        <div class="row">
            <div class="col">
                <h1>Search result: (X) found</h1>
            </div>
            <div class="col">

                <!-- OPTION 1: CHECKBOX -->
                <div class="btn-group" role="group" aria-label="Basic radio toggle button group">
                    <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked>
                    <label class="btn btn-outline-primary" for="btnradio1">Price: Lowest first</label>

                    <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off">
                    <label class="btn btn-outline-primary" for="btnradio2">Rating: Highest first</label>

                    <input type="radio" class="btn-check" name="btnradio" id="btnradio3" autocomplete="off">
                    <label class="btn btn-outline-primary" for="btnradio3">Distance to centrum: Nearest first</label>
                </div>


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
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <Filter/>
            </div>
            <div class="col-md-8">
                <Result/>
            </div>
        </div>
    </div>
</template>

<script>
import Filter from './SearchResultComponents/Filter.vue'
import Result from './SearchResultComponents/Result.vue'

export default ({
    components:{
        Filter,
        Result
    }
})
</script>