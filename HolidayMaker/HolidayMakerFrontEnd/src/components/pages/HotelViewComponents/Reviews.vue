<template>
    <div>
        <div class="row">
            <button type="button" class="btn btn-primary">Add review</button>
        </div>
        <div class="row">
            <h3>Guest reviews</h3>
        </div>
        <div class="row">
            <div class="col">
                <h3>Guest rating</h3>
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="reviewRatingDropdownMenu" data-bs-toggle="dropdown" aria-expanded="false">
                        Dropdown button
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="reviewRatingDropdownMenu">
                        <li><a class="dropdown-item" href="#">4+</a></li>
                        <li><a class="dropdown-item" href="#">3+</a></li>
                        <li><a class="dropdown-item" href="#">2+</a></li>
                        <li><a class="dropdown-item" href="#">All</a></li>
                    </ul>
                </div>
            </div>
            <div class="col">
                <h3>Language</h3>
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="reviewLanguageDropdownMenu" data-bs-toggle="dropdown" aria-expanded="false">
                            Dropdown button
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="reviewLanguageDropdownMenu">
                            <li><a class="dropdown-item" href="#">English</a></li>
                            <li><a class="dropdown-item" href="#">Swedish</a></li>
                        </ul>
                    </div>
            </div>
        </div>
    </div>
</template>