import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
// import { MemberDetailResolver } from './_resolvers/member-detail-resolver';
// import { MemberListResolver } from './_resolvers/member-list-resolver';
// import { ListsResolver } from './_resolvers/lists.resolver';
import { BookListComponent } from './book-list/book-list.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookSelectedListComponent } from './book-selected-list/book-selected-list.component';


export const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'books',
        component: BookListComponent,
        // resolve: {
        //   users: MemberListResolver
        // }
      },
      {
        path: 'books/:id',
        component: BookDetailComponent,
        // resolve: {
        //   user: MemberDetailResolver
        // }
      },
      {
        path: 'books-selected',
        component: BookSelectedListComponent,
        // resolve: {
        //   users: ListsResolver
        // }
      }
    ]
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];
