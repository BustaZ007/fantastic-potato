<template>
    <div class="text-input">
        <label>{{labelPlaceholder}}</label>
        <input  type="{{type}}" value="{{value}}" required = {{required}}>
    </div>
</template>

<script>
    export default {
        data(){
            return{
                inputField: ""
            }
        },
        props: {
            value: {
                required: true,
                type: String
            },
            labelPlaceholder: {
                required: false,
                type: String
            },
            type:{
                required: true,
                type: String
            },
            required:{
                type: Boolean,
                default : false
            }
        },
        computed:{
            validate(){
                
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
