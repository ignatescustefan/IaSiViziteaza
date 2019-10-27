import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ATypeService {

  constructor(private http: HttpClient) { }

  getAType(): Observable<any> {
    return this.http.get('https://localhost:44371/api/AttractionType');
  }
  postAttrtype(atype: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/AttractionType', atype);
  }
  postUser(user: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/User', user);
  }
  postLogin(user: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/User/login', user);
  }
  postAdmin(user: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/User/addAdminUser', user);
  }
  getAttractions(): Observable<any> {
    return this.http.get('https://localhost:44371/api/Attractions');
  }
  getAttractionsByTitle(title: string): Observable<any> {
    return this.http.get('https://localhost:44371/api/Attractions/' + title);
  }
  postAttraction(attraction: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/Attractions', attraction);
  }
  getComment(id: number): Observable<any> {
    return this.http.get('https://localhost:44371/api/Comment/' + id);
  }
  postComment(comment: any): Observable<any> {
    return this.http.post('https://localhost:44371/api/Comment/', comment);
  }
  checkUserPriority(email: string): Observable<any> {
    return this.http.get('https://localhost:44371/api/User/' + email);
  }
  getUserByemail(email: string): Observable<any> {
    return this.http.get(' https://localhost:44371/api/User/' + email);
  }
  UpdateUser(user: any): Observable<any> {
    return this.http.put('https://localhost:44371/api/User/update', user);
  }
  deleteComment(comment: any): Observable<any> {
    return this.http.delete('https://localhost:44371/api/Comment/delete/?id=' + comment);
  }
  deletedAttraction(attraction: any): Observable<any> {
    return this.http.delete('https://localhost:44371/api/Attractions/delete/?id=' + attraction);
  }
  deletedAttractionType(attractionType: any): Observable<any> {
    return this.http.delete('https://localhost:44371/api/AttractionType/delete/?id=' + attractionType);
  }
  LikeCount(update: any): Observable<any> {
    return this.http.put('https://localhost:44371/api/Attractions/update', update);
  }
  UpdateComment(update: any): Observable<any> {
    return this.http.put('https://localhost:44371/api/Comment/update', update);
  }
  getAttractionsById(id: string): Observable<any> {
    return this.http.get('https://localhost:44371/api/Attractions/test?id=' + id);
  }
}
