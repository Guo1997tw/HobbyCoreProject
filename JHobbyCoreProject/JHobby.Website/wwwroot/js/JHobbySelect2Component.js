const select2 = {
    props: ["options", "value"],
    emits: ['update:modelValue'],
    template: "<select><slot></slot></select>",
    mounted() {
        var vm = this;
        $(this.$el).select2({ data: this.options }).val(this.value)
            .trigger("change").on("change", function () {
                vm.$emit("update:value", this.value);
            });
    },
    watch: {
        value(value) {
            $(this.$el).val(value).trigger("change");
        },
        options(options) {
            $(this.$el).empty().select2({ data: options });
        }
    },
    destroyed() {
        $(this.$el).off().select2("destroy");
    }
};