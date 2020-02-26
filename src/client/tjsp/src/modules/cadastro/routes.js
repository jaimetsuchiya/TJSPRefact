export const CadastroRoutes = {

    path: "/cadastro",
    component: CadstroModule,
    children: [
        {
            path: ":id",
            name: "cadastro",
            component: CadastroPage
        },
        {
            path: "baixa",
            name: "baixa",
            component: BaixaPage
        },
    ]
}