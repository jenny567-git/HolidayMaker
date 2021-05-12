<template>
    <div>
        <div class="row pt-5">
            <div class="col-md-10">
                <h2>Guest reviews</h2>
            </div>
            <div class="col-md-2 text-end">
                <button type="button" class="btn btn-primary">Add review</button>
            </div>
        </div>
        <hr>
        <div class="row">
            <div class="col-md-4">
                
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="reviewRatingDropdownMenu" data-bs-toggle="dropdown" aria-expanded="false">
                        Rating
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="reviewRatingDropdownMenu">
                        <li><a class="dropdown-item" href="#">4+</a></li>
                        <li><a class="dropdown-item" href="#">3+</a></li>
                        <li><a class="dropdown-item" href="#">2+</a></li>
                        <li><a class="dropdown-item" href="#">All</a></li>
                    </ul>
                </div>
            </div>
            <div class="col-md-8">
                
                    <div class="dropdown text-end">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="reviewLanguageDropdownMenu" data-bs-toggle="dropdown" aria-expanded="false">
                            Language
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="reviewLanguageDropdownMenu">
                            <li><a class="dropdown-item" href="#">English</a></li>
                            <li><a class="dropdown-item" href="#">Swedish</a></li>
                        </ul>
                    </div>
            </div>
        <div class="row">
            <ReviewSubComp/>
        </div>
        </div>
    </div>
</template>

<script>
import ReviewSubComp from './ReviewComponents/ReviewSubComponent.vue'
export default {
    components: {
    ReviewSubComp
  }
}
</script>