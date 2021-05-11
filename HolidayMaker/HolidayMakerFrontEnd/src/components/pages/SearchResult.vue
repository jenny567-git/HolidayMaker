<template>
    <div>
        <div class="row">
            <h1>Search result</h1>
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