<template>
    <div>
        <Form v-model = "form">
            <input type="text" v-model = "form.login" value="000" required>
            <input type="password" v-model = "form.password" required>
            <button @click="authorization">Login</button>
        </Form>
        <div>
            <p>{{form.login}} / {{form.password}}</p>
        </div>
    </div>
</template>

<script>
    import Form from "../components/Form";

    export default {
        data(){ return{
            form: {
                login: "",
                password: ""
            }
        }
        },
        components: {
            Form
        },
        methods: {
            authorization(){
                this.$api.post("Authorization/Authorization", this.form).then(res => alert(res.data));
            }
        }
    }
</script>
