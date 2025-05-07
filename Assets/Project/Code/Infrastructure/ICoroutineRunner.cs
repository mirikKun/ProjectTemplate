using System.Collections;
using UnityEngine;

namespace Project.Code.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator load);
  }
}