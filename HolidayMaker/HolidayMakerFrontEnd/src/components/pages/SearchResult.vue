<template>
    <div>
        <div class="row">
            <h1>Search result</h1>
        </div>
        <div class="row">
            <div class="col">
                col 1
                <Filter/>
            </div>
            <div class="col">
                col2
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