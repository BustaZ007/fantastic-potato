<template>
    <div class="text-input">
        <label>{{labelPlaceholder}}</label>
        <input required>
    </div>
</template>

<script>
    export default {
        props: {
            value: {
                required: true,
                type: String
            },
            labelPlaceholder: {
                required: false,
                type: String
            }
        }
    }
</script>

<style>
    #app{
        margin-top: 50px;
    }

    .text-input label{
        display: block;
    }
</style>
