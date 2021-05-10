<template>
    <div>
        <h1>This is a hotel name {{hotel.name}}</h1>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4"> <!-- Stacked images -->
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                </div>
                <div class="col-md-8 "> <!-- Main image -->
                    <div>
                        <img class="img-fluid" src="https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg" alt="">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <ul class="nav nav-pills">
                        <li class="nav-item">
                            <a class="nav-link active" href="#">Overview</a> <!-- Replace with router link to -->
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Info</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Photos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Reviews</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Rooms</a>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
export default ({
    computed:{
        hotel(){
            return this.$store.state.hotels[this.$route.params.id];
        }
    }
})
</script>
